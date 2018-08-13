import React, { Component } from 'react';
import {Link} from 'react-router-dom'
import './Title.scss';

var Config = require('Config');

class Title extends Component {
  render() {
    return (
      <Link to={Config.url.root}>
        <div className="flex-item r-Title">simr</div>
        </Link>
    );
  }
}

export default Title;
