import React, { Component } from 'react';
import ReactPullToRefresh from 'react-pull-to-refresh';
import authService from './api-authorization/AuthorizeService'

export class WeatherForecast extends Component {
  static displayName = WeatherForecast.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.renderWeatherPageContent();
    this.populateWeatherData();
  }

  render() {
    this.renderWeatherPageContent();

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component shows the weather as retrieved from metaweather.com.</p>
        <br/>
        <ReactPullToRefresh onRefresh={this.handleLoadForecast.bind(this)} style={{textAlign: 'center'}}>
          <h3>Pull down this tag or the data table to refresh</h3>
          <div>{this.state.contents}</div>
        </ReactPullToRefresh>
      </div>
    );
  }
  
  static renderLoadingMessage() {
    return (
      <div>
        <h3>Loading... </h3> 
        <br/>
        <br/>
        <div class="spinner-border" role="status"/>
      </div>
    );
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Weather</th>
            <th>Image</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.state}</td>
              <td><img height='50px' width='50px' src={'https://www.metaweather.com/static/img/weather/png/' + forecast.imageUrlSuffix + '.png'}/></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  async populateWeatherData() {
    const token = await authService.getAccessToken();
    const init = { headers: !token ? {} : { 'Authorization': `Bearer ${token}` } }

    const response = await fetch('weatherforecast/belfast', init);
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }

  handleLoadForecast(){
    this.setState({loading: true });
    this.renderWeatherPageContent();
    this.populateWeatherData();
  }
  
  renderWeatherPageContent() {
    let contents = this.state.loading
      ? WeatherForecast.renderLoadingMessage()
      : WeatherForecast.renderForecastsTable(this.state.forecasts);
    this.state.contents = contents;
  }

}
