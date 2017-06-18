import { WebClientPage } from './app.po';

describe('web-client App', () => {
  let page: WebClientPage;

  beforeEach(() => {
    page = new WebClientPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
