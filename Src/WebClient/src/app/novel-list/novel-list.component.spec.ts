import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NovelListComponent } from './novel-list.component';

describe('NovelListComponent', () => {
  let component: NovelListComponent;
  let fixture: ComponentFixture<NovelListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NovelListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NovelListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
