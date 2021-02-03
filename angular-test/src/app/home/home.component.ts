import { Component, OnInit } from '@angular/core';
import { ChartType } from 'chart.js';
import { MultiDataSet, Label } from 'ng2-charts';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { CompanyShareholder } from './companyshareholder';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  private REST_API_SERVER = 'https://localhost:44397/api/v1/company';
  title = 'angular-test ***';
  CompanyShareholders: CompanyShareholder[];
  CompanyNames: any[];
  constructor(private httpClient: HttpClient) {
    this.CompanyShareholders = [];
    this.CompanyNames = [];
  }
  form = new FormGroup({
    website: new FormControl('')
  });

  doughnutChartLabels: Label[] = [];
  doughnutChartData: MultiDataSet = [[55, 25, 20]];
  doughnutChartType: ChartType = 'doughnut';

  handleError(error: HttpErrorResponse): void {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
  }

  get f(): any {
    return this.form.controls;
  }

  submit(): void {
    console.log(this.form.value);
  }

  ngOnInit(): void {
    const results = this.httpClient.get(this.REST_API_SERVER).subscribe((result: any) => {
      this.CompanyNames = [...new Set(result.map((y: any) => y.companyName))];
      this.CompanyShareholders = result;
      // console.log(this.CompanyNames);
    });

    // const results4 = this.httpClient.request('GET', this.REST_API_SERVER, {responseType: 'json'});
    // console.log(results4);
    // const results1 = this.httpClient.get<CompanyShareholder[]>(this.REST_API_SERVER);
    // console.log(results1);
    // const companies = [...new Set(results1.pipe(map(y: any) => y.companyName))];
  }

  changeCompany(e: any): any {
    console.log(e.target.value);
    const companyName = e.target.value;
    if (companyName !== 'Choose Company') {
      const shareholders = this.CompanyShareholders.filter(x => x.companyName === companyName);
      this.doughnutChartLabels = [...shareholders.map(x => x.shareholderName)];
      this.doughnutChartData = [[...shareholders.map(x => x.amount)]];
    }
  }
}
