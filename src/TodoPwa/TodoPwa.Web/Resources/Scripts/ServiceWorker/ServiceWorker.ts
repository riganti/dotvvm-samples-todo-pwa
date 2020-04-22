import { setCacheNameDetails } from "workbox-core"
import { registerRoute, setCatchHandler} from "workbox-routing"
import { precacheAndRoute} from "workbox-precaching"
import { ExpirationPlugin } from "workbox-expiration"
import { CacheFirst, CacheOnly, NetworkFirst, NetworkOnly, StaleWhileRevalidate } from "workbox-strategies"
import { OfflineFallbackRouteHandler } from "./OfflineFallbackRouteHandler"
import { firebase } from "@firebase/app"
import "@firebase/messaging"

declare let self: ServiceWorkerGlobalScope;
const serviceWorker = self as ServiceWorkerGlobalScope;
const offlineFallbackPage : string = "/offline/offline-page.html";

const cacheNamePrefix = "todo-pwa";
const cacheNameSuffix = "v1";
const cacheNamePrecache = "install-time";
const cacheNameRuntime = "run-time";

const runtimeCacheFullName = `${cacheNamePrefix}-${cacheNameRuntime}-${cacheNameSuffix}`;
const precacheCacheFullName = `${cacheNamePrefix}-${cacheNamePrecache}-${cacheNameSuffix}`;

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
messaging.setBackgroundMessageHandler(payload => {
    const notification = JSON.parse(payload.data.notification);
    const notificationTitle = notification.title;
    const notificationOptions: NotificationOptions = {
        body: notification.body
    };

    return self.registration.showNotification(notificationTitle, notificationOptions);
});


setCacheNameDetails({
    prefix: cacheNamePrefix,
    suffix: cacheNameSuffix,
    precache: cacheNamePrecache,
    runtime: cacheNameRuntime
});

precacheAndRoute([
    { url: offlineFallbackPage, revision: null },
    { url: "/offline/logo.png", revision: null },
    { url: "/?source=1", revision: null }
]);

registerRoute("/online-status-check", new NetworkOnly());

registerRoute(/.*\/.*/, new StaleWhileRevalidate({
    cacheName: "temporary",
    plugins: [
        new ExpirationPlugin({ maxAgeSeconds: 24 * 60 * 60 })
    ]
}));

setCatchHandler(new OfflineFallbackRouteHandler(offlineFallbackPage));

serviceWorker.oninstall = event => {
    serviceWorker.skipWaiting();
    event.waitUntil(install());
}

function install() {
    
}
