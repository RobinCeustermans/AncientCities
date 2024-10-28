import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CityTypeComponent } from './city-type.component';

describe('CityTypeComponent', () => {
  let component: CityTypeComponent;
  let fixture: ComponentFixture<CityTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CityTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CityTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
