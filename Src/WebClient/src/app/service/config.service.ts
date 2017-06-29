import { Injectable, OnInit } from '@angular/core';

/**
 * 配置服务
 * 获取默认配置，或者加载用户的自定义配置
 * @export
 * @class ConfigService
 */
@Injectable()
export class ConfigService implements OnInit {

  /** UI 的界面配置 */
  uiConfig: UiConfig;

  constructor() { }

  ngOnInit(): void {
    this.uiConfig = new UiConfig();
  }
}

/** UI 界面配置 */
export class UiConfig {

  /** 顶部导航条是否固定 */
  topNarvarIsFix: boolean;
  /** 侧边菜单是否显示 */
  sideNavbarIsShow: boolean;

  /** 侧边栏 宽度 */
  sideNavbarWidth: number;
  /** 页面容器最小的宽度，为了保证 footer 在浏览器的最底部 */
  pageWrapperMiniHeight: number;

  constructor() {
    this.topNarvarIsFix = true;
    this.sideNavbarIsShow = true;

    this.sideNavbarWidth = 220;
  }
}
