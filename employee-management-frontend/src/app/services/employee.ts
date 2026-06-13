import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth';

export interface Employee {
  id?: number;
  name: string;
  email: string;
  department: string;
  salary: number;
  joiningDate: string;
}

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  private apiUrl = 'http://localhost:5204/api/employees';

  constructor(private http: HttpClient, private auth: AuthService) {}

  private headers() {
    return new HttpHeaders({ Authorization: `Bearer ${this.auth.getToken()}` });
  }

  getAll() { return this.http.get<Employee[]>(this.apiUrl, { headers: this.headers() }); }
  add(emp: Employee) { return this.http.post<Employee>(this.apiUrl, emp, { headers: this.headers() }); }
  delete(id: number) { return this.http.delete(`${this.apiUrl}/${id}`, { headers: this.headers() }); }
}