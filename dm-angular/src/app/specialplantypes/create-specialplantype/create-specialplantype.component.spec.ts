import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSpecialplantypeComponent } from './create-specialplantype.component';

describe('CreateSpecialplantypeComponent', () => {
  let component: CreateSpecialplantypeComponent;
  let fixture: ComponentFixture<CreateSpecialplantypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateSpecialplantypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateSpecialplantypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
