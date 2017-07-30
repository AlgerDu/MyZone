import { Injectable, OnInit } from '@angular/core';
import { Http, Response, RequestOptionsArgs, RequestOptions, Headers } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { plainToClass, classToClass } from "class-transformer";

import "reflect-metadata";
import "es6-shim";

/**
 * http 请求 帮助服务
 * 主要用于对 HTTP 请求的通用处理
 * @export
 * @class HttpService
 */
@Injectable()
export class HttpService implements OnInit {

    constructor(
        private http: Http
    ) { }

    ngOnInit(): void {
    }

    /** 封装 angular 的 http ，用来做一些默认的处理 */
    post(url: string, body: any, options?: RequestOptionsArgs): Observable<Result> {

        if (options == null) {
            let headers = new Headers({ 'Content-Type': 'application/json' });
            options = new RequestOptions({ headers: headers });
        }

        return this.http.post(url, body, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    /** 将 http 请求回来的数据包装成 json 对象 */
    private extractData(res: Response) {
        let body = res.json();

        var result = classToClass<Result>(body.data);

        return result;
    }

    /** 处理 http 的请求错误 */
    private handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}

/** 和后端定义好的一个通用返回结果 */
export class Result {
    code: string;
    message: string;
    data: any;

    dataToClass<T>(): T {
        return classToClass<T>(this.data);
    }
}
