import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Landing page</h1>
        <br/>
        <br/>
        <h3>Welcome to the Weather Forecast app</h3>
        <br/>
        <br/>
        <p>You can click the Weather Forecast tab to get navigated to the feature.</p>
      </div>
    );
  }
}
