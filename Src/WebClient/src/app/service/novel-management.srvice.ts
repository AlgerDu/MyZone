import { Injectable, OnInit } from '@angular/core';
import { HttpService } from './http.service';
import { SearchConfition } from '../models/search';
import { NovelListModel } from '../models/novel-list.model';

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

    list(condition: SearchConfition): Array<NovelListModel> {
        return null;
    }
}
