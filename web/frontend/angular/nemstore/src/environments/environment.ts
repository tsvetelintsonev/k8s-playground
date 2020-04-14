export const environment = {
	production: false,
	Environment: window['env']['Environment'],
	PodName: window['env']['PodName'],
	PodNamespace: window['env']['PodNamespace'],
  BffUrl: window['env']['BffUrl'],
  GetProductsUrl: `${window['env']['BffUrl']}/api/v1.0/products`,
  CreateOrderUrl: `${window['env']['BffUrl']}/api/v1.0/orders`
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
