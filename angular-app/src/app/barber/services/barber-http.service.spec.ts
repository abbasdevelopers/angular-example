import { TestBed } from '@angular/core/testing';

import { BarberHttpService } from './barber-http.service';

describe('BarberHttpService', () => {
  let service: BarberHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BarberHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
