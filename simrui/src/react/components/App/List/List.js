import React, { Component } from 'react';
import './List.scss';

class ListItem extends Component {
    render() {
        return (
            <span className={(this.props.className || '') + ' simr-list-item'}>
                {this.props.render(this.props.item)}
            </span>
        );
    }
}

class List extends Component {
    constructor(props) {
        super(props);

        this.listRef = React.createRef();

        this.refCallback = element => {
            if (element) {
                if (element.scrollWidth > element.clientWidth) {
                    element.classList.add('simr-list-overflowed');
                }
                else {
                    element.classList.remove('simr-list-overflowed');
                }
            }
        };
    }

    /**
   * Add event listener
   */
    componentDidMount() {
        this.updateDimensions();
        window.addEventListener("resize", this.updateDimensions.bind(this));
    }

    /**
     * Remove event listener
     */
    componentWillUnmount() {
        window.removeEventListener("resize", this.updateDimensions.bind(this));
    }

    updateDimensions() {
        this.refCallback();
    }

    render() {
        return (
            <div ref={this.refCallback} className="simr-list">
                {this.props.items.map(item => {
                    return (
                        <ListItem
                            ref = {this.listRef}
                            key={item.key}
                            render={this.props.itemRender}
                            item={item}
                        />
                    );
                })}
            </div>
        );
    }
}

export default List;
