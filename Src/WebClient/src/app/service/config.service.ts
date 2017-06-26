import { Injectable } from '@angular/core';

/**
 * 配置服务
 * 获取默认配置，或者加载用户的自定义配置
 * @export
 * @class ConfigService
 */
@Injectable()
export class ConfigService {

  /** UI 的界面配置 */
  UiConfig: UiConfig;

  constructor() { }
}

/** UI 界面配置 */
export class UiConfig {

  /** 顶部导航条是否固定 */
  TopNarvarIsFix: boolean;
  /** 侧边菜单是否显示 */
  SideNavbarIsShow: boolean;

  /** 侧边栏 宽度 */
  SideNavbarWidth: number;
  /** 页面容器最小的宽度，为了保证 footer 在浏览器的最底部 */
  PageWrapperMiniHeight: number;

  constructor() {
    this.TopNarvarIsFix = true;
    this.SideNavbarIsShow = true;

    this.SideNavbarWidth = 220;
  }
}
