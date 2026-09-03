//Angular
import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

//Rxjs
import { Observable } from 'rxjs';

//Constants
import { getApiUrl } from '../../constants/app.config';

//Models
import { ApiResponse } from '../../models/ApiResponse.model';
import { Student } from '../../models/Student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = getApiUrl("STUDENTS");

  public getStudents(): Observable<ApiResponse<Student[]>> {
    return this.http.get<ApiResponse<Student[]>>(this.apiUrl);
  }

  public createStudent(student: Partial<Student>): Observable<ApiResponse<Student>> {
    return this.http.post<ApiResponse<Student>>(this.apiUrl, student);
  }

  public updateStudent(id: number, student: Partial<Student>): Observable<ApiResponse<Student>> {
    return this.http.put<ApiResponse<Student>>(`${this.apiUrl}/${id}`, student);
  }

  public deleteStudent(id: number): Observable<ApiResponse<any>> {
    return this.http.delete<ApiResponse<any>>(`${this.apiUrl}/${id}`);
  }
}
