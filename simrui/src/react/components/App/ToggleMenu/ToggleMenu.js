import React, { PureComponent } from 'react';
import { Motion, StaggeredMotion, spring } from "react-motion";
import {Link} from 'react-router-dom';
import './ToggleMenu.scss'

var Config = require('Config');

var classNames = require('classnames');
var _ = require('underscore');

const { noop } = _;

/**
 * <ToggleMenu />
 */
class ToggleMenu extends PureComponent {
  constructor() {
    super();
    
    this.state = {
      active: false,
    }
    
    this._onClick = this._onClick.bind(this);
  }
  
  _onClick() {
    this.setState({ 
      active: !this.state.active 
    });
  }

  render() {
    const hrefArrayLeft = [
         Config.url.book,
         Config.url.photo,
         Config.url.video,
    ];

    const hrefArrayRight = [
         Config.url.pathofexile,
         Config.url.chat,
         Config.url.root,
    ];

    const iconArrayLeft = [
        <span className="material-icons">book</span>
        , <span className="material-icons">camera_alt</span>
        , <span className="material-icons">videocam</span>
    ];

    const iconArrayRight = [
        'PoE'
        , <span className="material-icons">sms</span>
        , 4
    ];

    const tooltipArrayLeft = ['Book', 'Photo', 'Video'];
    const tooltipArrayRight = ['Path of Exile', 'Chat', 'Three'];
    
    return <div className="">
            <ButtonGroup>
                <StaggeredMotion defaultStyles={[{ x: -45, o: 0 }, { x: -45, o: 0 }, { x: -45, o: 0 }]} styles={prevInterpolatedStyles => prevInterpolatedStyles.map(
                            (_, i) => {
                                return i ===
                                    prevInterpolatedStyles.length - 1
                                    ? {
                                          x: spring(
                                              this.state.active ? 0 : -45,
                                              {
                                                  stiffness: 330,
                                                  damping: 20
                                              }
                                          ),
                                          o: spring(
                                              this.state.active ? 1 : 0,
                                              {
                                                  stiffness: 330,
                                                  damping: 20
                                              }
                                          )
                                      }
                                    : {
                                          x: spring(
                                              prevInterpolatedStyles[i + 1]
                                                  .x,
                                              {
                                                  stiffness: 330,
                                                  damping: 20
                                              }
                                          ),
                                          o: spring(
                                              prevInterpolatedStyles[i + 1]
                                                  .o,
                                              {
                                                  stiffness: 330,
                                                  damping: 20
                                              }
                                          )
                                      };
                            }
                        )}>
                    {interpolatingStyles => <ButtonGroup>
                            {interpolatingStyles.map((style, i) => (
                                <Link to={hrefArrayLeft[i]} key={i}>
                                    <Button
                                        key={i}
                                        style={{
                                            position: 'relative',
                                            right: style.x,
                                            opacity: style.o,
                                            pointerEvents: this.state.active
                                                ? 'auto'
                                                : 'none'
                                        }}
                                    >
                                        <Tooltip
                                            text={tooltipArrayLeft[i]}
                                        />
                                        {iconArrayLeft[i]}
                                    </Button>
                                </Link>
                            ))}
                        </ButtonGroup>}
                </StaggeredMotion>

                <Motion defaultStyle={{ s: 0.675 }} style={{ s: spring(
                            this.state.active ? 1 : 0.675,
                            { stiffness: 330, damping: 14 }
                        ) }}>
                    {interpolatingStyles => <Button className="button--large" onClick={this._onClick} style={{ transform: 'scale(' + interpolatingStyles.s + ')' }}>
            <span className={this.state.active ? 'simr-icon active' : 'simr-icon'} />
                        </Button>}
                </Motion>

                <StaggeredMotion defaultStyles={[{ x: -45, o: 0 }, { x: -45, o: 0 }, { x: -45, o: 0 }]} styles={prevInterpolatedStyles => prevInterpolatedStyles.map(
                            (_, i) => {
                                return i === 0
                                    ? {
                                          x: spring(
                                              this.state.active ? 0 : -45,
                                              {
                                                  stiffness: 330,
                                                  damping: 20
                                              }
                                          ),
                                          o: spring(
                                              this.state.active ? 1 : 0,
                                              {
                                                  stiffness: 330,
                                                  damping: 20
                                              }
                                          )
                                      }
                                    : {
                                          x: spring(
                                              prevInterpolatedStyles[i - 1]
                                                  .x,
                                              {
                                                  stiffness: 330,
                                                  damping: 20
                                              }
                                          ),
                                          o: spring(
                                              prevInterpolatedStyles[i - 1]
                                                  .o,
                                              {
                                                  stiffness: 330,
                                                  damping: 20
                                              }
                                          )
                                      };
                            }
                        )}>
                    {interpolatingStyles => <ButtonGroup>
                            {interpolatingStyles.map((style, i) => (
                                <Link to={hrefArrayRight[i]} key={i}>
                                    <Button
                                        key={i}
                                        style={{
                                            position: 'relative',
                                            left: style.x,
                                            opacity: style.o,
                                            pointerEvents: this.state.active
                                                ? 'auto'
                                                : 'none'
                                        }}
                                    >
                                        <Tooltip
                                            text={tooltipArrayRight[i]}
                                        />
                                        {iconArrayRight[i]}
                                    </Button>
                                </Link>
                            ))}
                        </ButtonGroup>}
                </StaggeredMotion>
            </ButtonGroup>
        </div>;
  }
}

/**
 * <Tooltip />
 */
const Tooltip = props => <span className="simr-tooltip">{props.text}</span>;

/**
 * <ButtonGroup />
 */
const ButtonGroup = props => (
    <div className="simr-button-group" style={props.style}>
        {props.children}
    </div>
);

/**
 * <Button />
 */
const Button = props => (
    <button
        className={classNames('simr-button', props.className)}
        style={props.style}
        onClick={props.onClick || noop}
    >
        {props.children}
    </button>
);

export default ToggleMenu;