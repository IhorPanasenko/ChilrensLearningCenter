import './App.css';
import './css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.js';

import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";

import Classes from './pages/Classes/Classes';
import Directions from './pages/Directions/Directions';
import Children from './pages/Children/Children';
import Specialists from './pages/Specialists/Specialists';

function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/Classes" element={<Classes />} />
          <Route path="/Directions" element={<Directions />} />
          <Route path='/Children' element={<Children />} />
          <Route path='/Specialists' element={<Specialists />} />
        /* Default Router */
          <Route path='/' element={<Navigate to="/Classes" />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
