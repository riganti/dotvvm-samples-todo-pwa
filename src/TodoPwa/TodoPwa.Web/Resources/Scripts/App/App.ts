/// <reference path="../typings/dotvvm/DotVVM.d.ts" />
import Axios from "axios"

const dotvvm = (window as any).dotvvm as DotVVM;

dotvvm.events.init.subscribe(async () => {
    setInterval(_ => {
        Axios.get("/online-status-check", { timeout: 3000 })
            .then(response => {
                if (response.status === 200) {
                    dotvvm.viewModels.root.viewModel.IsPageOffline(false);
                }
            })
            .catch(error => {
                dotvvm.viewModels.root.viewModel.IsPageOffline(true);
            });
    }, 10000);
});