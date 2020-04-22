/// <reference path="../typings/dotvvm/DotVVM.d.ts" />
import { firebase } from "@firebase/app"
import { FirebaseMessaging } from '@firebase/messaging-types';
import "@firebase/messaging"

const dotvvm = (window as any).dotvvm as DotVVM;

dotvvm.events.init.subscribe(async () => {
    // Periodically checking for online status
    setInterval(() => {
        const request = new XMLHttpRequest();
        request.open("GET", "/online-status-check");
        request.timeout = 3000;
        request.onload = () => {
            if (request.status === 200) {
                dotvvm.viewModels.root.viewModel.IsPageOffline(false);
            }
        };
        request.ontimeout = () => {
            dotvvm.viewModels.root.viewModel.IsPageOffline(true);
        };

        request.send();
    }, 10000);

    // Listening to online status changes
    window.addEventListener("online", () => {
        dotvvm.viewModels.root.viewModel.IsPageOffline(false);
    });

    window.addEventListener("offline", () => {
        dotvvm.viewModels.root.viewModel.IsPageOffline(true);
    });

    const firebaseConfig = {
        apiKey: "AIzaSyDKLkuN-fVG10-PXo0qvbYvdERtg_Hm_Zs",
        authDomain: "dotvvm-todo-pwa.firebaseapp.com",
        databaseURL: "https://dotvvm-todo-pwa.firebaseio.com",
        projectId: "dotvvm-todo-pwa",
        storageBucket: "dotvvm-todo-pwa.appspot.com",
        messagingSenderId: "768356710764",
        appId: "1:768356710764:web:e3a053393775d640a31b49",
        measurementId: "G-PLRKHBNMVH"
    };

    firebase.initializeApp(firebaseConfig);

    const messaging = firebase.messaging();
    let serviceWorkerRegistration: ServiceWorkerRegistration;
    if (navigator.serviceWorker.controller === undefined || navigator.serviceWorker.controller === null) {
        serviceWorkerRegistration = await navigator.serviceWorker.register("/service-worker.js");
    } else {
        serviceWorkerRegistration = await navigator.serviceWorker.getRegistration();
    }
    messaging.useServiceWorker(serviceWorkerRegistration);
    await messaging.requestPermission();
    const token = await messaging.getToken();
    console.log(token);
});