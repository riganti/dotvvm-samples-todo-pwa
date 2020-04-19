/// <reference path="../typings/dotvvm/DotVVM.d.ts" />
const dotvvm = (window as any).dotvvm as DotVVM;

dotvvm.events.init.subscribe(async () => {
    setInterval(_ => {
        const request = new XMLHttpRequest();
        request.open("GET", "/online-status-check");
        request.timeout = 3000;
        request.onload = _ => {
            if (request.status === 200) {
                dotvvm.viewModels.root.viewModel.IsPageOffline(false);
            }
        };
        request.ontimeout = _ => {
            dotvvm.viewModels.root.viewModel.IsPageOffline(true);
        };
        request.send();
    }, 10000);
});