import React, { Component } from 'react';
import Title from './../Title/Title'
import Userinfo from './../Userinfo/Userinfo'
import ToggleMenu from './../ToggleMenu/ToggleMenu'
import './Head.scss';

class Head extends Component {
  render() {
      return (
        <header className="r-header">
            <div className="flex flex-justify-space-between">
                <Title />
                <ToggleMenu />
                <Userinfo />
            </div>
        </header>
    );
  }
}

export default Head;
