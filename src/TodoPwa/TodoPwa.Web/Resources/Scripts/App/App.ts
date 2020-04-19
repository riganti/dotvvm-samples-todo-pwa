/// <reference path="../typings/dotvvm/DotVVM.d.ts" />
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
});