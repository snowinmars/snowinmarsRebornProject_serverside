import React, { PureComponent } from 'react';
import './List.scss';

class ListItem extends PureComponent {
    render() {
        return (
            <span className={(this.props.className || '') + ' simr-list-item'}>
                {this.props.render(this.props.item)}
            </span>
        );
    }
}

class List extends PureComponent {
    constructor(props) {
        super(props);

        this.state = { isOverflowed: false, firstHiddenChild: -1 };

        this.me = React.createRef();
    }

    componentDidMount() {
        window.addEventListener('resize', this.updateDimensions);
        this.updateChildrenVisability();
    }

    componentWillUnmount() {
        window.removeEventListener('resize', this.updateDimensions);
    }

    updateDimensions = () => {
        if (!this.me || !this.me.current) {
            return;
        }

        if (this.timer) {
            clearTimeout(this.timer);
        }

        this.timer = setTimeout(this.updateChildrenVisability, 300);
    };

    updateChildrenVisability = () => {
        var children = Array.from(this.me.current.children);
        var count = children.length;
        var thisRight = this.me.current.getBoundingClientRect().right;

        for (var i = 1; i < count; i++) {
            var thisChildRight = children[i].getBoundingClientRect().right;

            if (thisChildRight > thisRight) {
                this.setState({ firstHiddenChild: i });
                break;
            }
        }

        if (i === count) {
            this.setState({ firstHiddenChild: -1 });
        }
    };

    mapItem = item => {
        return (
            <ListItem
                key={item.key}
                render={this.props.itemRender}
                item={item}
            />
        );
    };

    isOverflowed() {
        return this.me.current.scrollWidth > this.me.current.clientWidth;
    }

    render() {
        var items = this.props.items.map(item => this.mapItem(item));

        var className = ' simr-list ';

        if (this.state.firstHiddenChild !== -1) {
            className +=
                ' hide-last-' + this.state.firstHiddenChild + '-children ';
        }

        var list = (
            <div ref={this.me} className={className}>
                {items}
            </div>
        );

        return list;
    }
}

export default List;
