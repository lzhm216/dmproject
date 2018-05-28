import { DocumentManagerTemplatePage } from './app.po';

describe('DocumentManager App', function() {
  let page: DocumentManagerTemplatePage;

  beforeEach(() => {
    page = new DocumentManagerTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
