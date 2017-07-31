import { Injectable, OnInit } from '@angular/core';
import { HttpService, Result } from './http.service';
import { SearchConfition } from '../models/search';
import { NovelListModel } from '../models/novel-list.model';

import 'rxjs/add/operator/toPromise';

/**
 * 小说管理 业务服务
 * 小说管理与后台交互
 * @export
 * @class NovelManagementService
 */
@Injectable()
export class NovelManagementService implements OnInit {

    constructor(
        private http: HttpService
    ) { }

    ngOnInit(): void {
    }

    list(condition?: SearchConfition): Promise<Array<NovelListModel>> {
        if (condition == null) {
            condition = new SearchConfition();
        }

        return this.http.post('/bookManagement/novel', condition)
            .toPromise()
            .then((result: Result) => {
                console.log(result);
                return null;
            })
            .catch((error) => {
                console.log(error);
                return error;
            });
    }
}
