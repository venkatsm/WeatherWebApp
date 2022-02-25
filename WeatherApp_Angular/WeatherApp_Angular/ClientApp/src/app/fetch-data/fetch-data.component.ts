import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public weatherInfo: WeatherInfo;
  title = 'Weather Forecast';
 
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Response>(baseUrl + 'weatherforecast/by?region=nj').subscribe(response => {
      if (response.success) {
        this.weatherInfo = response.result;
      }
    }, error => console.error(error));
  }
}

interface Response {
  success: boolean;
  result: WeatherInfo
}

interface WeatherInfo {
  region: string;
  next_Days: WeatherInfoDetail[];
  currentConditions: Currentconditions;
}

interface Currentconditions {
  dayHour : string;
  temp : Temp;
  precip : string;
  humidity : string;
  wind : Wind;
  iconURL : string;
  comment : string;
}

interface Temp {
  c: number;
  f: number;
}

interface Wind {
  km: number;
  mile: number;
}

interface WeatherInfoDetail {
  date: string;
  minTemperature: number;
  maxTemperature: number;
  summary: string;
}
