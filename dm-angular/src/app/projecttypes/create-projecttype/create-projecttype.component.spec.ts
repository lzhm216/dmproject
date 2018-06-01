import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateProjecttypeComponent } from './create-projecttype.component';

describe('CreateProjecttypeComponent', () => {
  let component: CreateProjecttypeComponent;
  let fixture: ComponentFixture<CreateProjecttypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateProjecttypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateProjecttypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
