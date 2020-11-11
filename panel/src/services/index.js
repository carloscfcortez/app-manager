import { stringify } from 'querystring'
import swal from 'sweetalert'
const BASE_URL = process.env.REACT_APP_API_URL
export default class Api {
  static async fetchMethods(method = 'GET', endpoint = '/', params = {}) {
    let headers = new Headers()
    headers.set('Content-Type', 'application/json')
    headers.set('Accept', 'application/json')
    headers.set('Access-Control-Allow-Origin', '*')

    let uri = BASE_URL + '/api' + endpoint
    let response

    if (method === 'GET' || method === 'DELETE') {
      uri += '?' + stringify(params)
      response = await fetch(uri, { method, headers })
    } else {
      response = await fetch(uri, {
        method,
        headers,
        body: JSON.stringify(params)
      })
    }

    if (response.ok) {
      const contentType = response.headers.get('content-type')
      if (contentType && contentType.indexOf('application/json') !== -1) {
        return await response.json()
      } else {
        return await response.text()
      }
    }

    if (!response.ok) {
      const { errors } = await response.json()
      swal('Ops! Ocorreu um erro.', JSON.stringify(errors), 'error')
      throw JSON.stringify(errors)
    }
  }

  static async get(endpoint, params = {}) {
    return Api.fetchMethods('GET', endpoint, params)
  }

  static async post(endpoint, body = {}, isFormData) {
    return Api.fetchMethods('POST', endpoint, body, isFormData)
  }

  static async put(endpoint, body = {}, isFormData) {
    return Api.fetchMethods('PUT', endpoint, body, isFormData)
  }

  static async delete(endpoint) {
    return Api.fetchMethods('DELETE', endpoint)
  }
}
