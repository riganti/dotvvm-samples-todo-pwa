import { setCacheNameDetails } from "workbox-core"
import { registerRoute, setCatchHandler} from "workbox-routing"
import { precacheAndRoute} from "workbox-precaching"
import { ExpirationPlugin } from "workbox-expiration"
import { CacheFirst, CacheOnly, NetworkFirst, NetworkOnly, StaleWhileRevalidate } from "workbox-strategies"
import { OfflineFallbackRouteHandler } from "./OfflineFallbackRouteHandler"

declare let self: ServiceWorkerGlobalScope;
const serviceWorker = self as ServiceWorkerGlobalScope;
const offlineFallbackPage : string = "/offline/offline-page.html";

const cacheNamePrefix = "todo-pwa";
const cacheNameSuffix = "v1";
const cacheNamePrecache = "install-time";
const cacheNameRuntime = "run-time";

const runtimeCacheFullName = `${cacheNamePrefix}-${cacheNameRuntime}-${cacheNameSuffix}`;
const precacheCacheFullName = `${cacheNamePrefix}-${cacheNamePrecache}-${cacheNameSuffix}`;

setCacheNameDetails({
    prefix: cacheNamePrefix,
    suffix: cacheNameSuffix,
    precache: cacheNamePrecache,
    runtime: cacheNameRuntime
});

precacheAndRoute([
    { url: offlineFallbackPage, revision: null },
    { url: "/offline/logo.png", revision: null }
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
