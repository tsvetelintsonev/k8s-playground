import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {

	public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const newRequest = req.clone(
      {
        headers: req.headers
          .set('Access-Control-Allow-Origin', '*')
          .set('Content-Type', 'application/json')
      });

    return next.handle(newRequest);
	}
}
