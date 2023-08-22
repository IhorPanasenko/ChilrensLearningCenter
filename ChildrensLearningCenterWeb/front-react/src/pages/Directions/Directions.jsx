import React from 'react'
import Header from '../../components/headerComponent/Header'

import styles from './Directions.css'
import { useState } from 'react';
import { useEffect } from 'react';
import axios from "axios";
import moment from "moment";

function Directions() {
    const requesstUrl = 'https://localhost:7296/api/Directions'
    const requesstUrlProcedure = 'https://localhost:7296/api/Directions/'

    const [resp, setResp] = useState([]);
    const [isRendered, setIsRendered] = useState(false);
    const [price, setPrice] = useState(0);

    useEffect(() => {
        getData();
    }, [])

    async function getData() {
        try {
            const response = await axios({
                method: "get",
                url: requesstUrl,
                data: JSON.stringify(),
                headers: { "Content-type": "apllication/json; charset=utf-8" }
            }).then((response) => {
                console.log(response.data);
                setIsRendered(true);
                setResp(response.data);
            })

        } catch (err) {
            alert(err);
        }
    }

    async function procedure() {
        try {
            const response = await axios({
                method: "get",
                url: requesstUrlProcedure+price,
                data: JSON.stringify(),
                headers: { "Content-type": "apllication/json; charset=utf-8" }
            }).then((response) => {
                console.log(response.data);
                getData();
            })

        } catch (err) {
            alert(err);
        }
    }

    console.log(resp);
    if (isRendered) {
        return (
            <>
                <Header></Header>
                <main>
                    <h1>Directions</h1>
                    <div className="info_table">
                        <table>
                            <tr>
                                <th>
                                    DirectioID
                                </th>
                                <th>
                                    Title
                                </th>
                                <th>
                                    Purpose
                                </th>
                                <th>
                                    Price
                                </th>
                                <th>
                                    Description
                                </th>
                            </tr>
                            {resp?.map((item) => (
                                <tr key={item.directionId}>
                                    <td>
                                        {item.directionId}
                                    </td>
                                    <td>
                                        {item.title}
                                    </td>
                                    <td>
                                        {item.purpose}
                                    </td>
                                    <td>
                                        {item.price} $
                                    </td>
                                    <td>
                                        {item.description}
                                    </td>
                                </tr>
                            ))}

                        </table>
                    </div>
                    <form action="get" className='p-4'>
                        <label className='form-label mt-4 mr-4' htmlFor='price'>input price: </label>
                        <input className='form-control' type="number" name="price" id="price" placeholder='100' onChange={(e)=> setPrice(parseInt(e.target.value))}/>
                        <div className="buttonWrapper">
                            <button type="button" class="btn btn-primary" onClick={procedure}>Execute Stored Procedure</button>
                        </div>
                    </form>
                </main>
            </>
        )
    }
    else {
        return (
            <div>
                <h1>Wait... Loading</h1>
            </div>
        )
    }
}

export default Directions
