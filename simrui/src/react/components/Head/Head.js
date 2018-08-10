import React, { Component } from 'react';
import Title from './../Title/Title'
import Userinfo from './../Userinfo/Userinfo'
import './Head.scss';

class Head extends Component {
  render() {
      return (
        <header>
            <div className="flex flex-justify-space-between">
                <Title />
                <Userinfo />
            </div>
        </header>
    );
  }
}

export default Head;
