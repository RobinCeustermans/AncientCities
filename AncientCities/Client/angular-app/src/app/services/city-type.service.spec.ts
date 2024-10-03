import { TestBed } from '@angular/core/testing';

import { CityTypeService } from './city-type.service';

describe('CityTypeService', () => {
  let service: CityTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CityTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
