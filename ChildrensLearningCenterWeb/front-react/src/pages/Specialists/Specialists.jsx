import React from 'react'
import Header from '../../components/headerComponent/Header';

import styles from './Specialists.css'
import { useState } from 'react';
import { useEffect } from 'react';
import axios from "axios";
import moment from "moment";
import TableFunction from '../../components/tableFunction/TableFunction';
import ScalarFunction from '../../components/ScalarFunction/ScalarFunction';

function Specialists() {
    const requesstUrl = 'https://localhost:7296/api/Specialist'
    const requesstUrlTwoTables = 'https://localhost:7296/api/Specialist/TwoTables'
    const [resp, setResp] = useState([]);
    const [respTwoTables, setRespTwoTables] = useState([]);
    const [isRendered, setIsRendered] = useState(false);
    const [isRendered2, setIsRendered2] = useState(false);

    useEffect(() => {
        getData();
        getDataTwoTables();
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

    async function getDataTwoTables() {
        try {
            const response = await axios({
                method: "get",
                url: requesstUrlTwoTables,
                data: JSON.stringify(),
                headers: { "Content-type": "apllication/json; charset=utf-8" }
            }).then((response) => {
                console.log(response.data);
                setIsRendered2(true);
                setRespTwoTables(response.data);
            })

        } catch (err) {
            alert(err);
        }
    }

    console.log(resp);
    if (isRendered && isRendered2) {
        return (
            <>
                <Header></Header>
                <main>
                    <h1>Specialists</h1>
                    <div className="info_table">
                        <table>
                            <tr>
                                <th>
                                    SpecialistId
                                </th>
                                <th>
                                    FirstName
                                </th>
                                <th>
                                    SecondName
                                </th>
                                <th>
                                    Phone number
                                </th>
                                <th>
                                    Years Experience
                                </th>
                                <th>
                                    Birthday Date
                                </th>
                                <th>
                                    DirectionId
                                </th>
                                <th>
                                    RoomId
                                </th>
                            </tr>
                            {resp?.map((item) => (
                                <tr key={item.specialistId}>
                                    <td>
                                        {item.specialistId}
                                    </td>
                                    <td>
                                        {item.firstName}
                                    </td>
                                    <td>
                                        {item.secondName}
                                    </td>
                                    <td>
                                        {item.telephone}
                                    </td>
                                    <td>
                                        {item.yearsExperience}
                                    </td>
                                    <td>
                                        {moment(item.birthdayDate).format("DD.MM.YYYY")}
                                    </td>
                                    <td>
                                        {item.directionId}
                                    </td>
                                    <td>
                                        {item.roomId}
                                    </td>
                                </tr>
                            ))}

                        </table>
                    </div>
                    <div className="two_tables p-5 m-5">
                        <h1>Info From Two Tables</h1>
                        <table>
                            <tr>
                                <th>
                                    SpecialistId
                                </th>
                                <th>
                                    FirstName
                                </th>
                                <th>
                                    SecondName
                                </th>
                                <th>
                                    Birthday Date
                                </th>
                                <th>
                                    DirectionId
                                </th>
                                <th>
                                    Direction Title
                                </th>
                                <th>
                                    Direction Price
                                </th>
                            </tr>
                            {respTwoTables?.map((item) => (
                                <tr key={item.specialistId}>
                                    <td>
                                        {item.specialistId}
                                    </td>
                                    <td>
                                        {item.firstName}
                                    </td>
                                    <td>
                                        {item.secondName}
                                    </td>
                                    <td>
                                        {moment(item.birthdayDate).format("DD.MM.YYYY")}
                                    </td>
                                    <td>
                                        {item.directionId}
                                    </td>
                                    <td>
                                        {item.title}
                                    </td>
                                    <td>
                                        {item.price}
                                    </td>
                                </tr>
                            ))}
                        </table>
                    </div>
                    <TableFunction />
                    <ScalarFunction />
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

export default Specialists
