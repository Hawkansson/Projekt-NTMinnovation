import { TestBed } from '@angular/core/testing';

import { NyhetspuffService } from './nyhetspuff.service';

describe('NyhetspuffService', () => {
  let service: NyhetspuffService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NyhetspuffService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
