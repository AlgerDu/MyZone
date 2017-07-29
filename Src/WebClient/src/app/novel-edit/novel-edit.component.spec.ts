import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NovelEditComponent } from './novel-edit.component';

describe('NovelEditComponent', () => {
  let component: NovelEditComponent;
  let fixture: ComponentFixture<NovelEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NovelEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NovelEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
