import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';

var Config = require('Config');
var Lib = require('./../../../Lib/componentUtils');

class AuthorsBooksTable extends Component {
    constructor(props) {
        super(props);

        var data = this.getDefaultData();

        this.state = {
            isInitByFirstPage: false,
            isInitByAllData: false,
            gotApiError: false,
            hasErrors: false,
            response: {
                code: -1,
                data: data
            }
        };

        this.options = Config.bootstrapTableOptions;
    }

    getDefaultData() {
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
            defaultUser.key = Math.random();
            defaultUser.authors[0].key = Math.random();
            data.push(defaultUser);
        }

        return data;
    }

    render() {
        return <BootstrapTable
            ref="table"
            data={this.state.response.data}
            striped
            hover
            pagination
            expandableRow={this.isExpandableRow}
            expandComponent={this.expandComponent}
            options={this.options}
        >
            <TableHeaderColumn dataField="title" isKey dataSort>
                Title
                </TableHeaderColumn>

            <TableHeaderColumn
                dataField="authors"
                dataSort
                dataFormat={this.authorsFormatter}
                expandable={false}
            >
                Authors
                </TableHeaderColumn>

            <TableHeaderColumn dataField="year" dataSort>
                Year
                </TableHeaderColumn>

            <TableHeaderColumn dataField="bookshelf" dataSort>
                Bookshelf
                </TableHeaderColumn>
        </BootstrapTable>
    }
}

export default AuthorsBooksTable;