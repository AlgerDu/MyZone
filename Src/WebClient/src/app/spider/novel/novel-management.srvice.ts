import { Injectable, OnInit } from '@angular/core';
import { NovelListModel } from './novel-list.model';

import 'rxjs/add/operator/toPromise';
import { SearchConfition } from '../../models/search';
import { HttpService, Result } from '../../service/http.service';

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

        return this.http.post('api/bookManagement/novel', condition)
            .toPromise()
            .then((result: Result) => {
                var d = result.dataToClassT<NovelListModel[]>();
                console.log(d);
                return null;
            })
            .catch((error) => {
                console.log(error);
                return error;
            });
    }
}
