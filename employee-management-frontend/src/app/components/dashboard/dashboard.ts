import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth';
import { EmployeeService, Employee } from '../../services/employee';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class DashboardComponent implements OnInit {
  employees: Employee[] = [];
  name = ''; email = ''; department = ''; salary = 0;

  constructor(private empService: EmployeeService, private auth: AuthService, private router: Router) {
    if (!this.auth.isLoggedIn()) this.router.navigate(['/login']);
  }

  ngOnInit() { this.loadEmployees(); }

  loadEmployees() {
    this.empService.getAll().subscribe({
      next: (data) => this.employees = data,
      error: () => { this.auth.logout(); this.router.navigate(['/login']); }
    });
  }

  addEmployee() {
    if (!this.name || !this.email || !this.department || !this.salary) {
      alert('Please fill all fields'); return;
    }
    this.empService.add({
      name: this.name, email: this.email,
      department: this.department, salary: this.salary,
      joiningDate: new Date().toISOString()
    }).subscribe(() => {
      this.name = ''; this.email = ''; this.department = ''; this.salary = 0;
      this.loadEmployees();
    });
  }

  deleteEmployee(id: number) {
    if (confirm('Are you sure?')) {
      this.empService.delete(id).subscribe(() => this.loadEmployees());
    }
  }

  logout() { this.auth.logout(); this.router.navigate(['/login']); }
}