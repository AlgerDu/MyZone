import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-novel-edit',
  templateUrl: './novel-edit.component.html',
  styleUrls: ['./novel-edit.component.less']
})
export class NovelEditComponent implements OnInit {

  author: string;
  name: string;

  constructor(
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    //this.route.snapshot.params

    this.author = this.route.snapshot.params['author'];
    this.name = this.route.snapshot.params['name'];

    console.log(this.author);
  }

}
