import React, { Component } from 'react';
import {Route} from 'react-router';
import Head from './../../App/Head/Head'
import Bot from './../../App/Bot/Bot'
import WelcomePage from './../WelcomePage/WelcomePage'
import {BrowserRouter} from 'react-router-dom';

class MainPage extends Component {
  render() {
      return (
        <BrowserRouter>
            <div>
              <Head />

              <Route exact={true} path = '/' component={WelcomePage} />

              <Bot />
            </div>
        </BrowserRouter>
    );
  }
}

export default MainPage;
