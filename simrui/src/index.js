import React from 'react';
import ReactDOM from 'react-dom';
import './index.scss';
import './../src/css/flex.scss'
import './../src/css/grid.scss'
import MainPage from './react/components/Page/MainPage/MainPage';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<MainPage />, document.getElementById('root'));
registerServiceWorker();
