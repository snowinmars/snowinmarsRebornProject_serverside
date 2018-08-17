import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import './../../../../../node_modules/react-bootstrap-table/dist/react-bootstrap-table.min.css';
import './BookPage.scss';
import AuthorList from './AuthorList';
import BookExpand from './BookExpand';

var Config = require('Config');
var Lib = require('./../../../Lib/componentUtils');

class BookPage extends Component {
    constructor(props) {
        super(props);

        var defaultUser = {
            title: 'Loading...',
            authors: [
                {
                    name: {
                        givenName: 'Loading...',
                        fullMiddleName: 'Loading...',
                        familyName: 'Loading...',
                        key: 0
                    }
                }
            ],
            year: 'Loading...',
            imageUrl: 'Loading...',
            additionalInfo: 'Loading...',
            bookshelf: 'Loading...',
            flibustaUrl: 'Loading...',
            libRusEcUrl: 'Loading...',
            liveLibUrl: 'Loading...',
            owner: 'Loading...',
            pageCount: 'Loading...',
            key: 0
        };

        var data = [];

        for (var i = 0; i < 10; i++) {
            data.push(defaultUser);
        }

        this.state = {
            isInit: false,
            response: {
                code: -1,
                data: data
            },
            gotApiError: false,
            hasErrors: false
        };

        this.getRow = this.getRow.bind(this);
    }

    componentDidMount() {
        Lib.fetchAndHandle({
            uri: Config.apiurl.book.filter,
            onSuccess: json =>
                this.setState({
                    response: JSON.parse(json),
                    isInit: true
                }),
            onError: err =>
                this.setState({
                    gotApiError: true,
                    hasErrors: true,
                    isInit: false
                })
        });
    }

    getRow(i) {
        return this.state.response.data[i.index];
    }

    isExpandableRow() {
        return true;
    }

    expandComponent(row) {
        return <BookExpand row={row} />;
    }

    authorsFormatter(cell) {
        return <AuthorList authors={cell} />;
    }

    render() {
        var loaderErrorClass = "";
        
        if (this.state.gotApiError) {
            loaderErrorClass += ' simr-loader-api-error ';
        } 

        if (this.state.isInit) {
            loaderErrorClass += " hidden ";
        } else {
            loaderErrorClass += " simr-loader ";
        }

        const loader = <div className={loaderErrorClass + "simr-flex simr-flex-align-center simr-flex-justify-center"}>
            <div class="sk-folding-cube">
                <div class="sk-cube1 sk-cube" />
                <div class="sk-cube2 sk-cube" />
                <div class="sk-cube4 sk-cube" />
                <div class="sk-cube3 sk-cube" />
            </div>
        </div>;

        const options = Config.bootstrapTableOptions;

        const table = <BootstrapTable
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

        

        return (
            <div>
                {loader}
                {table}
            </div>
        );
    }
}

export default BookPage;
