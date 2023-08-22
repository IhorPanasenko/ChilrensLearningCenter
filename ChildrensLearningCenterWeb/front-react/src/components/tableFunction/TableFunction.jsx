import React from 'react'

import { useState } from 'react';
import { useEffect } from 'react';
import axios from "axios";
import moment from "moment";
import styles from "./TableFunction.css"

function TableFunction() {
    const requesstUrl = 'https://localhost:7296/api/Specialist/TableFunction'
    const [resp, setResp] = useState([]);

    async function getData() {
        try {
            const response = await axios({
                method: "get",
                url: requesstUrl,
                data: JSON.stringify(),
                headers: { "Content-type": "apllication/json; charset=utf-8" }
            }).then((response) => {
                console.log(response.data);
                setResp(response.data);
            })

        } catch (err) {
            alert(err);
        }
    }

    console.log(resp);

    return (
        <>
        <h1 className='pt-3'>table function</h1>
            <table>
                <tr>
                    <th>
                        SpecialistId
                    </th>
                    <th>
                        DirectionId
                    </th>
                </tr>
                {resp?.map((item) => (
                    <tr key={item.directionID+""+item.specialistID}>
                        <td>{item.specialistID}</td>
                        <td>{item.directionID}</td>
                    </tr>
                ))}
            </table>
            <div className="buttonWrapper">
                <button type="button" class="btn btn-primary" onClick={getData}>Execute Table Function</button>
            </div>
        </>
    )
}

export default TableFunction
