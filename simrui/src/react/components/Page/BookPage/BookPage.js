import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import './../../../../../node_modules/react-bootstrap-table/dist/react-bootstrap-table.min.css';
import './BookPage.scss';

var Config = require('Config');

class BSTable extends Component {
    render() {
        return (
            <div>
                <div>{this.props.data.title}</div>
                <div>{this.props.data.pageCount}</div>
            </div>
        );
    }
}

class AuthorList extends Component {
    render() {
        if (this.props.authors) {
            return (
                <div className="simr-author-list">
                    {this.props.authors.map(function(author) {
                        return (
                            <span class="simr-author-item">
                                <span>
                                    {author.givenName} {author.fullMiddleName}{' '}
                                    {author.familyName}
                                </span>
                            </span>
                        );
                    })}
                </div>
            );
        }
    }
}

class BookPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            response: {
                code: -1,
                data: []
            }
        };

        this.getRow = this.getRow.bind(this);

        fetch(Config.apiurl.book.filter, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'User-Agent': 'Fiddler'
            }
        })
            .then(res => {
                var j = res.json();
                console.log(j);
                return j;
            })
            .then(json => this.setState({ response: JSON.parse(json) }));
    }

    getRow(i) {
        return this.state.response.data[i.index];
    }

    isExpandableRow(row) {
        return true;
    }

    expandComponent(row) {
        return <BSTable data={row} />;
    }

    authorsFormatter(cell, row, formatExtraData, rowIdx) {
        return <AuthorList authors={cell} />;
    }

    render() {
        const options = Config.bootstrapTableOptions;

        return (
            <BootstrapTable
                ref="table"
                data={this.state.response.data}
                striped
                hover
                pagination
                expandableRow={this.isExpandableRow}
                expandComponent={this.expandComponent}
                options={options}
            >
                <TableHeaderColumn dataField="title" isKey dataSort>
                    Title
                </TableHeaderColumn>

                <TableHeaderColumn
                    dataField="authors"
                    dataSort
                    dataFormat={this.authorsFormatter}
                >
                    Authors
                </TableHeaderColumn>

                <TableHeaderColumn dataField="year" dataSort>
                    Year
                </TableHeaderColumn>
            </BootstrapTable>
        );
    }
}

export default BookPage;
