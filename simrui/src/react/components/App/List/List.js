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
    refCallback = element => {
        if (element) {
            if (element.scrollWidth > element.clientWidth) {
                element.classList.add('simr-list-overflowed');
            }
        }
    };

    render() {
        return (
            <div
                ref={this.refCallback}
                className={(this.props.className || '') + ' simr-list'}
            >
                {this.props.items.map(item => {
                    return (
                        <ListItem
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
