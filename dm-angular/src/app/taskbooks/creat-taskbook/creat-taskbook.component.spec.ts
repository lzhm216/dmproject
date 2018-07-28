import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatTaskbookComponent } from './creat-taskbook.component';

describe('CreatTaskbookComponent', () => {
  let component: CreatTaskbookComponent;
  let fixture: ComponentFixture<CreatTaskbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatTaskbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatTaskbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
