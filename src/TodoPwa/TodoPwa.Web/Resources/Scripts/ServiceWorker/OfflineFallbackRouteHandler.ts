import { RouteHandlerObject, RouteHandlerCallbackOptions } from "workbox-core"

export class OfflineFallbackRouteHandler implements RouteHandlerObject {
    private offlineFallbackPage: string;

    constructor(offlineFallbackPage: string) {
        this.offlineFallbackPage = offlineFallbackPage;
    }

    handle(options: RouteHandlerCallbackOptions): Promise<Response> {
        const fetchEvent = options.event as FetchEvent;
        if (fetchEvent !== undefined && fetchEvent !== null && fetchEvent.request.destination === "document") {
            return caches.match(this.offlineFallbackPage);
        } else {
            return new Promise((): Response => Response.error());
        }
    }
}