export const environment = {
  production: false,
  Environment: window['env']['Environment'],
  PodName: window['env']['PodName'],
  PodNamespace: window['env']['PodNamespace'],
  BffUrl: window['env']['BffUrl'],
  GetProductsUrl: `${window['env']['BffUrl']}/api/v1.0/products`,
  CreateOrderUrl: `${window['env']['BffUrl']}/api/v1.0/orders`
};
