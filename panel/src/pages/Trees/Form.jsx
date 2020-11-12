import React, { useState, useEffect } from 'react'
import styled from 'styled-components'
import {
  Container,
  Row,
  Col,
  Button,
  Card,
  CardHeader,
  CardFooter,
  CardBody,
  Input
} from 'reactstrap'
import NavbarDefault from '../../components/Navbars/NavbarDefault'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import Api from '../../services/index'
import swal from 'sweetalert'
export default function EditTree(props) {
  const { match, history } = props
  const [species, setSpecies] = useState([])
  const [groups, setGroups] = useState([])
  const [data, setData] = useState({
    SpecieId: '',
    GroupId: '',
    Description: '',
    Age: ''
  })
  let title = 'Árvores'

  const handleGoBack = () => {
    history.goBack('/trees')
  }

  useEffect(() => {
    ;(async function () {
      setSpecies(await Api.get('/specie'))
      setGroups(await Api.get('/group'))
    })()
  }, [])

  useEffect(() => {
    async function load() {
      const { id } = match?.params
      setData(await Api.get(`/tree/${id}`))
    }
    if (match?.params?.id) load()
  }, [match?.params?.id])

  const handleSave = async () => {
    console.log(data)
    if (data?.Id) {
      await Api.put(`/tree/${data?.Id}`, { ...data })
      swal('Sucesso!', 'Registro atualizado com sucesso.', 'success').then(
        (isConfirm) => {
          if (isConfirm) handleGoBack()
        }
      )
    } else {
      await Api.post(`/tree`, { ...data })
      swal('Sucesso!', 'Registro cadastrado com sucesso.', 'success').then(
        (isConfirm) => {
          if (isConfirm) handleGoBack()
        }
      )
    }
  }

  const changeValue = (fieldName, value) => {
    console.log(value)
    var property = {}
    var descriptor = Object.create({
      enumerable: true,
      writable: true,
      configurable: true,
      value: null
    })
    descriptor.value = value
    Object.defineProperty(property, fieldName, descriptor)

    setData({ ...data, ...property })
  }
  return (
    <div>
      <NavbarDefault />
      <ContainerBody>
        <Row>
          <Col>
            <Card>
              <CardHeader>
                <Row>
                  <Col>
                    <h3>Cadastro de {title}</h3>
                  </Col>
                </Row>
              </CardHeader>
              <CardBody>
                <Row>
                  <Col md={3}>
                    <label>Espécie</label>

                    <Input
                      type="select"
                      // options={[{ value: 1, text: 'teste' }]}
                      onChange={(event) =>
                        changeValue('SpecieId', event?.target?.value)
                      }
                      defaultValue={data?.SpecieId}
                    >
                      <option>Selecione a Espécie</option>
                      {species?.map((item) => (
                        <option
                          selected={data?.SpecieId === item?.Id}
                          key={item?.Id}
                          value={item?.Id}
                        >
                          {item?.PopularName + ' - ' + item?.ScientificName}
                        </option>
                      ))}
                    </Input>
                  </Col>
                  <Col md={3}>
                    <label>Espécie</label>

                    <Input
                      type="select"
                      // options={[{ value: 1, text: 'teste' }]}
                      onChange={(event) =>
                        changeValue('GroupId', event?.target?.value)
                      }
                      defaultValue={data?.GroupId}
                    >
                      <option>Selecione o Grupo</option>
                      {groups?.map((item) => (
                        <option
                          selected={data?.GroupId === item?.Id}
                          key={item?.Id}
                          value={item?.Id}
                        >
                          {item?.Name}
                        </option>
                      ))}
                    </Input>
                  </Col>
                  <Col md={3}>
                    <label>Descrição</label>
                    <Input
                      onChange={(event) =>
                        changeValue('Description', event?.target?.value)
                      }
                      value={data?.Description}
                    />
                  </Col>
                  <Col md={3}>
                    <label>Idade</label>
                    <Input
                      type="number"
                      onChange={(event) =>
                        changeValue('Age', event?.target?.value)
                      }
                      value={data?.Age}
                    />
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
                {/* <Row>
                  <Col md={1}>
                    <Button
                      color="info"
                      onClick={() => history.goBack()}
                      outline
                    >
                      <FontAwesomeIcon icon="arrow-left" /> Voltar
                    </Button>
                  </Col>
                  <SpaceVertical />
                </Row> */}
                <Button
                  color="success"
                  onClick={handleSave}
                  className="float-md-left"
                >
                  <FontAwesomeIcon icon="check-circle" /> Salvar
                </Button>
                <Button
                  color="info"
                  onClick={handleGoBack}
                  outline
                  className="float-md-right"
                >
                  <FontAwesomeIcon icon="arrow-left" /> Voltar
                </Button>
              </CardFooter>
            </Card>
          </Col>
        </Row>
        <SpaceRow />
      </ContainerBody>
    </div>
  )
}

const ContainerBody = styled(Container)`
  padding-top: 10px;
`

const SpaceRow = styled(Row)`
  padding-top: 5px;
`
