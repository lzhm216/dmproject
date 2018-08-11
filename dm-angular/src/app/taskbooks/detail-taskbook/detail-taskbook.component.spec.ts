import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailTaskbookComponent } from './detail-taskbook.component';

describe('DetailTaskbookComponent', () => {
  let component: DetailTaskbookComponent;
  let fixture: ComponentFixture<DetailTaskbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailTaskbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailTaskbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
