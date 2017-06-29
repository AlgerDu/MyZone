import { Component, OnInit } from '@angular/core';
import { NovelListModel } from '../models/novel-list.model';

@Component({
  selector: 'app-novel-list',
  templateUrl: './novel-list.component.html',
  styleUrls: ['./novel-list.component.less']
})
export class NovelListComponent implements OnInit {

  novels: Array<NovelListModel>;

  constructor() { }

  ngOnInit() {
    this.novels = [
      {
        uid: 'n1', name: '修真聊天群', author: '圣骑士的传说',
        totalWords: 391.1, lastUpdateTime: new Date('2017/6/29')
      }
      ,
      {
        uid: 'n2', name: '斗战狂潮', author: '星战风暴',
        totalWords: 10, lastUpdateTime: new Date()
      }
      ,
      {
        uid: 'n3', name: '神级英雄', author: '大烟缸',
        totalWords: 10, lastUpdateTime: new Date()
      }
    ];
  }

}
