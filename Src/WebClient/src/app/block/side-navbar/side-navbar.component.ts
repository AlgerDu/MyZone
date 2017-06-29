import { Component, OnInit } from '@angular/core';
import { UiConfig, ConfigService } from '../../service/config.service';

@Component({
  selector: 'app-side-navbar',
  templateUrl: './side-navbar.component.html',
  styleUrls: ['./side-navbar.component.less']
})
export class SideNavbarComponent implements OnInit {

  uiConfig: UiConfig;

  constructor(
    config: ConfigService
  ) {
    this.uiConfig = config.uiConfig;
  }

  ngOnInit() {
  }

}
