import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSpecialplanComponent } from './create-specialplan.component';

describe('CreateSpecialplanComponent', () => {
  let component: CreateSpecialplanComponent;
  let fixture: ComponentFixture<CreateSpecialplanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateSpecialplanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateSpecialplanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
