import React, { Component } from 'react';
import './Title.scss';
import Api from './../Api/Api';

class Title extends Component {
  render() {
    return (
      <a href={Api.url.root}>
        <div className="flex-item r-Title">simr</div>
        </a>
    );
  }
}

export default Title;
